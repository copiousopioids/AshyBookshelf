/* queries_reports.sql */

/* FUNCTIONS */

/* Function 1 */
/* function to delete from Cardholder_Item 
used when a cardholder returns an item to 
show that that item is no longer checked out */
delimiter $$
create function deleteci (id int)
returns bool
begin
delete from Cardholder_Item where item_id=id;
return true;
end; $$
delimiter ;

/* Function 2 */
/* function to set item to available
used when a cardholder returns an item to 
list the item as available in the items table */
delimiter $$
create function setavail (id int)
returns bool
begin
update Items set available=1 where item_id=id;
return true;
end; $$
delimiter ;



/* QUERIES */


/* 1. searches books based on title */
select available, title, i.item_id from Books b 
join Items i 
on i.item_id=b.item_id 
where i.title like @param1;

/* 2. searches movies based on title */
select available, title, i.item_id 
from Movies m 
join Items i 
on i.item_id=m.item_id 
where i.title like @param1;

/* 3. search books based on genre */
select available, title, i.item_id from Books b join Items i on i.item_id=b.item_id join Item_Genre ig on ig.item_id=i.item_id join Genres g on g.genre_id=ig.genre_id where g.genre like @param1;

/* 4. search movies bases on genre */
select available, title, i.item_id from Movies m join Items i on i.item_id=m.item_id join Item_Genre ig on ig.item_id=i.item_id join Genres g on g.genre_id = ig.genre_id where g.genre like @param1;

/* 5. searches books based on a person associated with it that has
a name like the search string */
select available, title, i.item_id from Items i join People_Roles_Items pri on pri.item_id=i.item_id join People p on p.person_id=pri.person_id where i.item_id in (select b.item_id from Books b) and p.first_name like @name_like or p.last_name like @name_like2;

/* 6. searches movies based on a person associated with it that has
a name like the search string */
select available, title, i.item_id from Items i join People_Roles_Items pri on pri.item_id=i.item_id join People p on p.person_id=pri.person_id where i.item_id in (select m.item_id from Movies m) and p.first_name like @name_like or p.last_name like @name_like2;

/* 7. gets all the information (except people and genres) about a 
movie to be used in the listbox that displays more info about the
 selected item */
select i.item_id,i.title,i.available,i.weekly_fine,i.damage_fine,c.condit,m.description,m.duration,m.studio,m.barcode_no from Items i left outer join Item_Condition ic on ic.item_id=i.item_id left outer join Condit c on c.code=ic.code left outer join Movies m on m.item_id=i.item_id where i.item_id=@item_id;

/* 8. gets all the information (except people and genres) about a book
 to be used in the listbox that displays more infor about the selected
item */
select i.item_id, i.title, i.available, i.weekly_fine, i.damage_fine, c.condit, b.num_pages, b.publisher, b.isbn from Items i left outer join Item_Condition ic on ic.item_id=i.item_id left outer join Condit c on c.code=ic.code left outer join Books b on b.item_id=i.item_id where i.item_id=@item_id;

/* 9. gets all the genres associated with the item with a given 
item_id - since an item can have more than one genre -used in the more 
info listbox */
select g.genre from Genres g join Item_Genre ig on ig.genre_id=g.genre_id where ig.item_id=@item_id;

/* 10. gets all the information for all the people associated with the
item with a given item_id - used in the more info listbox */
select r.role,p.first_name,p.last_name, p.birth_date, p.death_date, p.twitter from People_Roles_Items pri join Roles r on r.role_code=pri.role_code join People p on p.person_id=pri.person_id where pri.item_id=@item_id;

/* 11. gets the total balance owed by a particular user */
select sum(f.amount) from Fines f 
join Owes o 
on o.fine_id=f.fine_id 
where f.paid=false and o.c_id = @curUser_int 
group by o.c_id;

/* 12. gets a list of all fines associated with a given cardholder_id */
select f.fine_id, amount, paid, due_date, description from Fines f join Owes o on o.fine_id=f.fine_id where o.c_id=@curUser_int;

/* 13. selects all unpaid fines for a given username - used in PayFine
function to get a list of all unpaid fines so that they can be set to
paid */
select f.fine_id, amount, paid, due_date, description from Fines f join Owes o on o.fine_id=f.fine_id join Cardholders c on o.c_id= c.c_id where c.username= @username && f.paid =0;

/* 14. selects all the info for an individual fine */
SELECT * FROM Fines WHERE fine_id = @fine_id;

/* 15. gets the specified item's info so that it can be verified that
the item is available when a user tries to check it out */
SELECT * FROM Items WHERE item_id = @item_id;

/* 16. gets an item_id from cardholder_item - used to verify that an
item is indeed checked out when a user tries to return an item */
SELECT item_id FROM Cardholder_Item WHERE item_id = @item_id;

/* 17. gets the items checked out by the cardholder with the given
c_id */
select i.item_id, i.title, ci.due_date from Cardholder_Item ci join Items i on i.item_id=ci.item_id where ci.c_id=@custId and i.available=false;

/* 18. searches cardholders by username -used on staff side */
select * from Cardholders where username like @username_like;

/* 19. searches the database for existing customers with a given
username - used when adding a customer to see if the new customer's
username will still be unique (i.e., is not already taken) */
SELECT username, c_id FROM Cardholders WHERE username = @username;

/* 20. gets all info for given username when checking credentials
when a user tries to log in */
SELECT * FROM Cardholders WHERE username = @username;



/* REPORTS */


/* 21. list all awards */
SELECT award_id, name FROM Awards;

/* 22. list all genres - usually used in genre drop-down box */
SELECT genre_id, genre FROM Genres;

/* 23. get all possible roles */
SELECT * FROM Roles;

/* 24. get all contributors - used when displaying all contributors to
choose from when adding a contributor of a new item */
SELECT * FROM People;

/* 25. gets all cardholders - used to list all customers in the staff
window */
SELECT * FROM Cardholders;