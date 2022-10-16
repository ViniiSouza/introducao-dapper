CREATE DATABASE IntroducaoADapper
GO
USE IntroducaoDapper
CREATE TABLE Tarefas(
Id int not null IDENTITY(1,1),
Descricao NVARCHAR(MAX) not null,
IsCompleta bit not null)