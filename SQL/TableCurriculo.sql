
create table Curriculo(
	cpf varchar(11) primary key not null,
	nome varchar not null,
	endereco varchar not null,
	telefone varchar(14)  not null,
	pretencao_salarial float not null,
	cargo_pretendido varchar not null,
	formacao_academica varchar not null,
	experiencia_proficional varchar,
	idiomas varchar
)