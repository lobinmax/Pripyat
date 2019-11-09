IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_DocumentsCorrectingMultiFactor' AND type = 'P')
    DROP PROCEDURE Pr_DocumentsCorrectingMultiFactor
GO
--
CREATE PROCEDURE dbo.Pr_DocumentsCorrectingMultiFactor
/*	���������� ���� ��� ���������� �� �������� �� ������
															*/
	@AbonentNum			VARCHAR(12) = '',			-- ����� ��������
	@PeriodStart		INT			= NULL,			-- ������ ������ ���������
	@DocumentNumber		VARCHAR(20)	= '',			-- �������� ����� ��������� - ���������
	@DtControl			DATETIME	= '20150713'	-- ���� ����������� �����������
AS
	/* SET NOCOUNT ON */
/*
exec dbo.Pr_DocumentsCorrectingMultiFactor @AbonentNum = '131400496500', @PeriodStart = 201607, @DtControl = '20170320'
exec dbo.Pr_DocumentsCorrectingMultiFactor @AbonentNum = '131400490470', @PeriodStart = 201607, @DtControl = '20170320'
exec dbo.Pr_DocumentsCorrectingMultiFactor @AbonentNum = '131400409900', @PeriodStart = 201607, @DtControl = '20170320'
exec dbo.Pr_DocumentsCorrectingMultiFactor @AbonentNum = '131700702680', @PeriodStart = 201607, @DtControl = '20170320'
*/

DECLARE @iDocs	INT
DECLARE	iCursor	CURSOR LOCAL FORWARD_ONLY STATIC FOR

SELECT		DocumentId FROM Documents 
WHERE		num = @AbonentNum AND 
			PeriodNumber >= @PeriodStart AND 
			DocumentTypeId = 2 -- ��� ���������

OPEN  iCursor
-- ��������� ������ �������
FETCH NEXT FROM iCursor INTO @iDocs
-- ���� ���� ���� ������
WHILE @@FETCH_STATUS = 0   
BEGIN 
			EXEC Documents_CorrectingDocuments 
						@DocumentId				= @iDocs,						--- ��������������� ��������
						@EnergyTypeId			= 1,
						@PlanId					= 3,            				--- ���� ������
						@ReasonCorrectId		= 42,           				--- ������� ����������� (1 ... 19)
						@InitRecalcTypeId		= 1,            				--- ��������� ����������� (1 ... 6)
																			/*
																				1. ��� ��
																				2. ��� ��
																				3. ������� ��
																				4. ������� � ����������� ������������������
																				5. ������� ����
																				6. ��������� �������
																			*/
/*VARCHAR(20)*/			@DocumentNumber			= @DocumentNumber,	            --- �������� ����� ��������� �����������
						@DtControl				= @DtControl,					--- ���� ����������� �����������
						@PeriodNumberBegin		= NULL,							--- ������ ������� �����������
						@PeriodNumberEnd		= NULL,							--- ����� ������� �����������
						@NewIndication			= 0,            				--- ����� ��������� ��� �����������
						@Consumption			= 0,							--- ��������� �����������
						@SumCharges				= 0,							--- ��������� �� �����������
/*VARCHAR(256)*/		@Notes					= '',							--- �������
						@RecalcObjectId			= 1,							--- 1 - ��������� ��������
																				--- 2 - �� ������
																				--- 3 - ���� ��������
						@Transaction			= 1,
						@Function				= 1,
						@MessageDiag			= 1

FETCH NEXT FROM iCursor INTO @iDocs
END  
CLOSE iCursor
DEALLOCATE iCursor
 /*
                                      1	  45	�������� ��������� ��������
                                      2	  21	�������� ��������� �������� �����������
                                      3	  22	�������� ��������� ���������� �����������
                                      4	  50	��������� ��������� ������� �����
                                      5	  26	������� � ������� ���������
                                      6	  51	��������� ���������� ������
                                      7	  8	  ��������� ������������� �������������/����������
                                      8	  16	��������� ���� �����
                                      9	  2	  ��������� ����������� �����������
                                      10	42	��������� ���������� ����� ��� ���
                                      11	36	������������� �������� ����������
                                      12	24	�������� ���������� �� ���� ������ �����
                                      13	41	������� � ����������� ��������
                                      14	47	���������� �� �������������� ���������������
                                      15	28	���������� �� ������� ����
                                      16	32	������������� ���������� �� ��
                                      17	48	��������� ���������� ������� ��� ���
                                      18	43	�������� �������� � ��� "����" ��� ���
                                      19	52	������������� ���������� �� ���. ������
                                    */
RETURN
--
GO
GRANT EXECUTE ON Pr_DocumentsCorrectingMultiFactor TO KvzWorker