1.0 VISTA ---> 10 Autores que más venden en la historia 

SELECT        TOP (10) ROW_NUMBER() OVER (ORDER BY a.au_fname) AS id, a.au_fname, a.au_lname, count(ta.title_id) AS cantidad
FROM            dbo.authors AS a INNER JOIN
                         dbo.titleauthor AS ta ON a.au_id = ta.au_id INNER JOIN
                         dbo.sales AS s ON ta.title_id = s.title_id
GROUP BY ta.au_id, a.au_fname, a.au_lname, s.title_id
HAVING        (COUNT(s.title_id) >= 1)



2.0 VISTA ---> Listado de libro que tienen más de un autor

SELECT        ROW_NUMBER() OVER (ORDER BY ta.title_id) AS id, a.au_lname, a.au_fname, t .title
FROM            titleauthor AS ta INNER JOIN
                         authors AS a ON ta.au_id = a.au_id INNER JOIN
                         titles AS t ON ta.title_id = t .title_id
WHERE        ta.title_id IN
                             (SELECT        ta.title_id
                               FROM            titleauthor AS ta JOIN
                                                         authors AS a ON ta.au_id = a.au_id
                               GROUP BY ta.title_id
                               HAVING         count(title_id) > 1)


3.0 PROCEDIMIENTO ALMACENADO ---> Pagar comisiones por año

USE [pubs]
GO
/****** Object:  StoredProcedure [dbo].[SP_CommisionsPerYear]    Script Date: 13/03/2018 05:22:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[SP_CommisionsPerYear] (@year int) as
select a.au_fname + ' ' + a.au_lname as FullName, datename(month, s.ord_date) as Month, datename(year, s.ord_date) as Year, cast(sum(t.price * qty) * case ta.au_ord when 1 then .1 when 2 then .08 else .05 end as decimal(6, 2)) as Comission
from sales s
inner join titles t
on t.title_id = s.title_id
inner join titleauthor as ta
on ta.title_id = t.title_id
inner join authors as a
on a.au_id = ta.au_id
where datename(year, s.ord_date) = @year
group by datename(month, s.ord_date), ta.au_ord, a.au_fname + ' ' + a.au_lname, datename(year, s.ord_date)



4.0 FUNCION Y VISTA ---> 5 Libros que han mantenido sus ventas

create function FN_GetLastYears()
returns table
return (
select top 3 year(ord_date) as Years
from sales
group by year(ord_date)
order by year(ord_date) desc
);

SELECT        TOP (5) ROW_NUMBER() over(order by t.title) as id,  t.title
FROM            dbo.sales AS s INNER JOIN
                         dbo.titles AS t ON t.title_id = s.title_id
WHERE        (YEAR(s.ord_date) IN
                             (SELECT        Years
                               FROM            dbo.FN_GetLastYears() AS FN_GetLastYears_1))
GROUP BY t.title