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
/* join seems faster */
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

/*who is borrowing item with title like %X% ? */
/* only returns users-wouldn't be able to distinguish if multiple books
match the title. Could force them to search by exact title instead:
where i.title='X' 
otherwise, use joins so you can show which user checked out which book */
select name, username from Cardholders c
where c.c_id in
	( select c_id from Cardholder_Item ci
    where ci.item_id in
        ( select item_id from Items i
        where i.title like '%the%' )
     );

/* which items with property Y are available */
select * from Items where available=true;
select * from Items where available=false;

select * from Items i
join Item_Condition ic
on ic.item_id=i.item_id
join Condit c
on c.code=ic.code
where c.condit='Excellent'/*or Good or Fair or Poor */;

/* show total amount user owes in unpaid fines (to use sum() function) */
select c.c_id, c.name, sum(f.amount) from Fines f
join Owes o
on o.fine_id=f.fine_id
join Cardholders c
on c.c_id=o.c_id
where f.paid=false
group by c.c_id

/* showing all unpaid fines for current user - do need this if just displaying all fines in the listbox? */
select c.name, c.username, c.c_id, f.amount, f.due_date, f.paid, f.description from Fines f
join Owes o
on o.fine_id=f.fine_id
join Cardholders c
on c.c_id=o.c_id
where c.c_id=2 and paid=false; /* or where c.username=? */

/* show all fines for current user */
select c.name, c.username, c.c_id, f.amount, f.due_date, f.paid, f.description from Fines f
join Owes o
on o.fine_id=f.fine_id
join Cardholders c
on c.c_id=o.c_id
where c.c_id=2;

/* Reports */

/* list all awards in alph order with all recips in year order */
/* use left outer joins to include all awards and fill with nulls */
select a.name, p.first_name, p.last_name, aw.year_won
from Awards a
join Awards_Won aw
on aw.award_id=a.award_id
join People p
on p.person_id=aw.person_id
order by a.name asc, aw.year_won asc;

/* list what each person has borrowed (list people in alph order, and the items in alph order ) */
select c.name, i.title, ci.due_date, ci.time
from Cardholders c
join Cardholder_Item ci
on ci.c_id=c.c_id
join Items i
on i.item_id=ci.item_id
order by c.name asc, i.title asc;


/* list what current user has checked out at the moment */
select i.title,ci.time, ci.due_date from Cardholder_Item ci
join Items i
on i.item_id=ci.item_id
where ci.c_id=2 and i.available=false; /*our current Cardholder_Item table
doesn't track whether it's been returned so we need to check the Items table
to see if it is still unavailable */

/* list all outstanding fines for all users */ /* what makes it outstanding? -unpaid for now */
select c.name, f.fine_id, f.description, f.amount, f.due_date, f.paid from 
Fines f join Owes o
on o.fine_id=f.fine_id
join Cardholders c
on c.c_id=o.c_id
where paid=false
order by c.name asc, fine_id asc;

/* list all cardholders in alph order with their contact info */
select c.name,c.phone, c.address from Cardholders c
order by c.name asc;

/* list what all items are checked out -i.e. unavailable */
/* 1st one just lists titles of all checked out */
select i.title from Items i
where available=false;
/* 2nd lists title and who checked it out, followed by due_date */
select i.title, c.name, ci.due_date
from Cardholders c
join Cardholder_Item ci
on ci.c_id=c.c_id
join Items i
on i.item_id=ci.item_id
where i.available=false;


/* function to set available when checking out/returning an item */
create function setavail (id int, status bool)
returns bool
begin
update Items set available=status where item_id=id;
return true;
end;

/* function to delete from Cardholder_Item */
delimiter $$
create function deleteci (id int)
returns bool
begin
delete from Cardholder_Item where item_id=id;
return true;
end; $$
delimiter ;