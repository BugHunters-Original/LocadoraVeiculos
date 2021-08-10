select * from TBCliente

delete from TBCliente

DBCC CHECKIDENT ( TBCliente, RESEED )

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
                        'Gabriel Marques',
						'Guarujá',
						'(49)99803-5074',
						'01190011956',
						'PF'
	                );