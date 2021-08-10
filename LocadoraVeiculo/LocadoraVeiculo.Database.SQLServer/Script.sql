INSERT INTO TBCLIENTE 
	                (
		                [NOME], 
		                [ENDERECO], 
		                [TELEFONE],
                        [CPF_CNPJ], 
		                [TIPO]
	                ) 
	                VALUES
	                (
                        'ANDREY', 
                        'SANTA HELENA',
                        '49998035074',
		                '01190011956', 
		                'FÍSICO'
	                );
SELECT * FROM TBCLIENTE

DELETE FROM TBCLIENTE

DBCC CHECKIDENT ( TBCLIENTE, RESEED )
