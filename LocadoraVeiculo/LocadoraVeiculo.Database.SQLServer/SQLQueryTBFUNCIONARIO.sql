INSERT INTO [TBFUNCIONARIO]
                (
                    [NOME],       
                    [SALARIO], 
                    [CPF],
                    [DATA_ENTRADA],                    
                    [USUARIO],                                                           
                    [SENHA]            
                )
            VALUES
                (
                    'Luisa Farias',
                    2000.0,
                    '09923900090',
                    '09/09/2001',
                    'bom_dia',
                    '123Luisa'
                    
                )

                SELECT * FROM TBFUNCIONARIO

                UPDATE [TBFUNCIONARIO]
                SET 
                    [NOME] = 'LUCAS',       
                    [SALARIO] = 3000, 
                    [CPF] = '09909099',
                    [DATA_ENTRADA] = '09/09/2021',                    
                    [USUARIO] = 'LUCAS',                                                           
                    [SENHA] = 'LUCAS123'

                WHERE [ID] = 1