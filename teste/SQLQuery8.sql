
select f.ID,f.Nome, f.DataNascimento, f.Salario, NomeGenero 
from FuncionarioTB f
inner join GeneroTB g on f.GeneroID = g.ID
where DataNascimento between '1980-01-01' and '2001-01-01' and f.GeneroID = 1;

select f.ID,f.Nome, f.DataNascimento, f.Salario, NomeGenero 
from FuncionarioTB f
inner join GeneroTB g on f.GeneroID = g.ID
where DataNascimento between '1980-01-01' and '2001-01-01' and f.GeneroID = 2;

select f.ID,f.Nome,f.DataNascimento,f.Salario,g.NomeGenero,d.ID,d.Nome,d.DataNascimento,gd.NomeGenero
from FuncionarioTB f
left join DependentesTB d on f.ID = d.FuncionarioID
Inner join GeneroTB g on g.ID = f.GeneroID
left join GeneroTB gd on gd.ID = d.GeneroID;
