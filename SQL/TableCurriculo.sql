
create table Curriculo(
	cpf varchar(11) primary key not null,
	nome varchar(500) not null,
	endereco varchar(500) not null,
	telefone varchar(14)  not null,
	pretencao_salarial decimal not null,
	cargo_pretendido varchar(500) not null,
	formacao_academica varchar(500) not null,
	experiencia_proficional varchar(500),
	idiomas varchar(500)
)
