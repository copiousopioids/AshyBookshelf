/* queries */
/* so far I've just done select * for all the queries. May need changed
depending on what we find out we actually need to have the query return. */
/* Also when we prepare the statements in the code, the things we're
searching by will need replaced with ? */

/* search item by genre */
select * from Items i
left outer join Item_Genre ig
on ig.item_id = i.item_id
left outer join Genres g
on g.genre_id = ig.genre_id
where g.genre like '%Fantasy%';

/* search item by title */
select * from Items i
where title like '%The%';

/* search book by title */
select * from Books b
join Items i
on i.item_id = b.item_id
where title like '%The%';

/* search book by person */
select * from Books b
join Items i
on i.item_id = b.item_id
join People_Roles_Items pri
on pri.item_id=i.item_id
join People p
on p.person_id = pri.person_id
where p.first_name like '%Depp%' or p.last_name like '%Depp';

/* search book by genre */
select * from Books b
join Items i
on i.item_id = b.item_id
join Item_Genre ig
on ig.item_id = i.item_id
join Genres g
on g.genre_id = ig.genre_id
where g.genre = "Fantasy";

/*search movies by title-different way than above, not sure which is better */
select * from Items i
where i.item_id in (select m.item_id from Movies m)
and i.title like '%The%';

/*search movie by person */
select * from Items i /*or from movies like the above verson from books? */
join People_Roles_Items pri
on pri.item_id = i.item_id
join People p
on p.person_id = pri.person_id
where i.item_id in (select m.item_id from Movies m)
and p.first_name like '%Cameron%' or p.last_name like '%Cameron%';

/* search movie by genre */
select * from Movies m
join Items i
on i.item_id = m.item_id
join Item_Genre ig
on ig.item_id = i.item_id
join Genres g
on g.genre_id = ig.genre_id
where g.genre = "Action";
