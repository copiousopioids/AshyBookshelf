/* Some fake data to populate database for testing purposes */
/* Will be added to as needed */

insert into Items values (1, "Nerve", true, 5.00, 10.00);
insert into Items values (2, "Salt", true, 5.00, 10.00);
insert into Items values (3, "Alanna", true, 5.00, 12.00);
insert into Items values (4, "Pirates of the Caribbean", true, 5.00, 10.00);
insert into Items values (5, "Avatar", true, 5.00, 10.00);
insert into Items values (6, "The Scorpio Races", true, 5.00, 12.00);
insert into Items values (7, "Karate Kid", true, 5.00, 10.00);
insert into Items values (8, "Agent Cody Banks", true, 5.00, 10.00);

insert into Movies values (1, "Movie starring Dave Franco and Emma Roberts about dares",
															1.6, "Universal", "111-222-111-222");
insert into Movies values (2, "Movie starring Angelina Jolie",
															1.6, "Universal", "111-222-222-333");
insert into Movies values (4, "Movie starring Johnny Depp",
															1.6, "Universal", "111-222-444-555");
insert into Movies values (5, "Movie about blue people",
															1.6, "Universal", "111-222-555-666");
insert into Movies values (7, "the karate kid movie",
															1.6, "Universal", "111-222-777-888");
insert into Movies values (8, "agent movie with cody banks",
															1.6, "Universal", "111-222-888-999");

insert into Books values (3, 300, "Hyperion", "222-111-333-444");
insert into Books values (6, 300, "Pearson", "222-111-666-777");

insert into Cardholders values (1, "austen", "austen", "555-555-5555", "Austen Henry", "Manhattan KS");
insert into Cardholders values (2, "zmarcolesco", "password", "222-222-2222", "Zach Marcolesco", "Manhattan KS");

insert into Genres values (1, "Fantasy");
insert into Genres values (2, "Nonfiction");
insert into Genres values (3, "Action");

insert into Condit values (1, "Excellent");
insert into Condit values (2, "Good");
insert into Condit values (3, "Fair");
insert into Condit values (4, "Poor");

insert into People values (1, "Maggie", "Stiefvater", '2017-11-14', NULL, NULL);
insert into People values (2, "Johnny", "Depp", '2017-11-13', NULL, NULL);
insert into People values (3, "James", "Cameron", '2017-11-14', NULL, NULL);

insert into Roles values (1, "Actor");
insert into Roles values (2, "Director");
insert into Roles values (3, "Author");

insert into People_Roles_Items values (2, 1, 4);
insert into People_Roles_Items values (1, 3, 6);
insert into People_Roles_Items values (3, 2, 5);

insert into Item_Condition values (1, 1);
insert into Item_Condition values (2, 1);
insert into Item_Condition values (3, 1);
insert into Item_Condition values (4, 4);
insert into Item_Condition values (5, 3);
insert into Item_Condition values (6, 2);

insert into Item_Genre values (1, 3);
insert into Item_Genre values (6, 1);
insert into Item_Genre values (3, 2);
