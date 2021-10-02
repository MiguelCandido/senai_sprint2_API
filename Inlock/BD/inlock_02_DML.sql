use inlock_games_manha
go

insert into tipoUsuario(tipo) values
('ADMINISTRADOR'), ('CLIENTE')
go

insert into usuario(idTipoUsuario,email, senha) values
(1, 'admin@admin.com', 'admin'), (2,'cliente@cliente.com','cliente')
go

insert into estudio(nomeEstudio) values
('Blizzard'),('Rockstar Studios'), ('Square Enix')
go

insert into jogo(nomeJogo,dataLançamento,descrição,idEstudio,valor) values
('Diablo 3', '2012-05-05', 'Um jogo que contém bastante ação e é viciante, seja você um novato ou um fã.', 1, 99.00),
('Red Dead Redemption II,', '2018-10-26', 'jogo eletrônico de ação-aventura western.', 2, 120.00)
go