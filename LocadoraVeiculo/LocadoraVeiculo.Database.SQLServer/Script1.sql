
delete from TBClienteCNPJ
DBCC CHECKIDENT ( TBClienteCNPJ, RESEED )

delete from TBClienteCPF
DBCC CHECKIDENT ( TBClienteCPF, RESEED )

delete from TBLocacao
DBCC CHECKIDENT ( TBLocacao, RESEED )

delete from TBFuncionario
DBCC CHECKIDENT ( TBFuncionario, RESEED )

SELECT
                        CD.[ID],
		                CD.[NOMEC], 
		                CD.[ENDERECOC], 
		                CD.[TELEFONEC],
                        CD.[CPF], 
		                CD.[RG],
                        CD.[CNH],
                        CD.[DATA_VALIDADE],
                        CD.[ID_CLIENTE],
                        CT.[NOME],
                        CT.[ENDERECO],
                        CT.[TELEFONE],
                        CT.[CNPJ]
	                FROM
                        TBCLIENTECPF AS CD LEFT JOIN
                        TBCLIENTECNPJ AS CT
                    ON
                        CT.ID = CD.ID_CLIENTE
                    WHERE 
                        CD.ID_CLIENTE = 9036;