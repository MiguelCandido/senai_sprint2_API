use inlock_games_manha
go

--Listar todos os jogos;
select * from jogo
go

--Listar todos os estúdios;
select * from estudio
go

--Listar todos os usuários;
select * from usuario
go

--Listar todos os jogos e seus respectivos estúdios;
select idJogo, nomeJogo, descrição, nomeEstudio, FORMAT (dataLançamento , 'dd-MM-yyyy') as 'data de lançamento' ,valor 
from jogo inner join estudio on jogo.idEstudio = estudio.idEstudio
go

--Buscar e trazer na lista todos os estúdios com os respectivos jogos
--Obs.: Listar todos os estúdios mesmo que eles não contenham nenhum jogo de referência;
select estudio.idEstudio,nomeEstudio, nomeJogo, FORMAT (dataLançamento , 'dd-MM-yyyy') as 'data de lançamento' , valor 
from estudio left join jogo on estudio.idEstudio = jogo.idEstudio
go

-- Buscar um usuário por e-mail e senha (login);
create function logar(@email varchar(40), @senha varchar(40)) returns table as return
select idUsuario,idTipoUsuario, email, senha FROM usuario
where email = @email and senha = @senha
go

select * from logar('admin@admin.com', 'admin')
go

--Buscar um jogo por idJogo;
create function buscarJogo(@id int) returns table as return
select idJogo, nomeJogo, descrição, FORMAT (dataLançamento , 'dd-MM-yyyy') as 'data de lançamento' ,valor FROM jogo
where idJogo = @id
go

select * from buscarJogo(2)
go

--Buscar um estúdio por idEstudio;
create function buscarEstudio(@idE int) returns table as return
select idEstudio,nomeEstudio FROM estudio
where idEstudio = @idE
go

select * from buscarEstudio(3)
go