/*
Plantilla de script posterior a la implementación							
--------------------------------------------------------------------------------------
 Este archivo contiene instrucciones de SQL que se anexarán al script de compilación.	
 Inserta o Actualiza datos estáticos
--------------------------------------------------------------------------------------
*/
merge [General].[IdType] as [target]
using (
    values 
    (1, 'RC', 'R.C.', 'Registro Cibil'),
    (2, 'TI', 'T.I.', 'Tarjeta de Identidad'),
    (3, 'CC', 'C.C.', 'Cédula de Ciudadania'),
    (4, 'NIT', 'N.I.T.', 'Nit'),
    (5, 'PT', 'P.T.', 'Pasaporte'),
    (6, 'VCOD', 'VCOD', 'Virtual Cod')
) as [source] ([Key], [Code], [Name], [Description])
on target.[Key] = [source].[Key]
when matched then
    update set 
        [Key] = [source].[Key],
        [Code] = [source].[Code],
        [Name] = [source].[Name],
        [Description] = [source].[Description]
when not matched then
    insert ([Key], [Code], [Name], [Description])
    values ([source].[Key], [source].[Code], [source].[Name], [source].[Description]);