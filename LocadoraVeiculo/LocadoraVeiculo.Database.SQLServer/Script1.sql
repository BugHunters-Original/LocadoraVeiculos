select * from TBClienteCNPJ
delete from TBClienteCNPJ
DBCC CHECKIDENT ( TBClienteCNPJ, RESEED )

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
delete from TBVeiculos

select * from TBClienteCPF
delete from TBClienteCPF
DBCC CHECKIDENT ( TBClienteCPF, RESEED )
