use inlock_games_manha
go

--Listar todos os jogos;
select * from jogo
go

--Listar todos os est�dios;
select * from estudio
go

--Listar todos os usu�rios;
select * from usuario
go

--Listar todos os jogos e seus respectivos est�dios;
select idJogo, nomeJogo, descri��o, nomeEstudio, FORMAT (dataLan�amento , 'dd-MM-yyyy') as 'data de lan�amento' ,valor 
from jogo inner join estudio on jogo.idEstudio = estudio.idEstudio
go

--Buscar e trazer na lista todos os est�dios com os respectivos jogos
--Obs.: Listar todos os est�dios mesmo que eles n�o contenham nenhum jogo de refer�ncia;
select estudio.idEstudio,nomeEstudio, nomeJogo, FORMAT (dataLan�amento , 'dd-MM-yyyy') as 'data de lan�amento' , valor 
from estudio left join jogo on estudio.idEstudio = jogo.idEstudio
go

-- Buscar um usu�rio por e-mail e senha (login);
create function logar(@email varchar(40), @senha varchar(40)) returns table as return
select idUsuario,idTipoUsuario, email, senha FROM usuario
where email = @email and senha = @senha
go

select * from logar('admin@admin.com', 'admin')
go

--Buscar um jogo por idJogo;
create function buscarJogo(@id int) returns table as return
select idJogo, nomeJogo, descri��o, FORMAT (dataLan�amento , 'dd-MM-yyyy') as 'data de lan�amento' ,valor FROM jogo
where idJogo = @id
go

select * from buscarJogo(2)
go

--Buscar um est�dio por idEstudio;
create function buscarEstudio(@idE int) returns table as return
select idEstudio,nomeEstudio FROM estudio
where idEstudio = @idE
go

select * from buscarEstudio(3)
go