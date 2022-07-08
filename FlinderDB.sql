create database if not exists flinder;
use flinder;

create table if not exists airport(
	id int auto_increment unique not null primary key,
    airport_id varchar(3) unique not null,
    `name` varchar(64) unique not null,
    country varchar(32) not null,
    city varchar(32) unique not null,
    adress varchar(128) unique null
);

create table if not exists airline(
	id int auto_increment unique not null primary key,
    `name` varchar(32) unique not null
);

insert into airport (airport_id, `name`, country, city, adress) values ("SOF", "Sofia Airport", "Bulgaria", "Sofia", "Bulevard „Hristofor Kolumb“ 1, 1540");
insert into airport (airport_id, `name`, country, city, adress) values ("BOJ", "Burgas Airport", "Bulgaria", "Burgas", "Administration floor 2 office 201, 8016 Burgas");
insert into airport (airport_id, `name`, country, city, adress) values ("VAR", "Varna Airport", "Bulgaria", "Varna", "Varna Airport, 9154 Varna");
insert into airport (airport_id, `name`, country, city, adress) values ("PDV", "Plovdiv International Airport", "Bulgaria", "Plovdiv", "4112 Krumovo");
insert into airport (airport_id, `name`, country, city, adress) values ("HND", "Haneda International Airport", "Japan", "Tokyo", "Hanedakuko, Ota City, Tokyo 144-0041");
insert into airport (airport_id, `name`, country, city, adress) values ("ATL", "Hartsfield-Jackson Atlanta International Airport", "USA", "Atlanta", "6000 N Terminal Pkwy, Atlanta, GA 30320");
insert into airport (airport_id, `name`, country, city, adress) values ("DFW", "Dallas/Fort Worth International Airport", "USA", "Texas", "2400 Aviation Dr, DFW Airport, TX 75261");
insert into airport (airport_id, `name`, country, city, adress) values ("ORD", "Chicago O’Hare International Airport", "USA", "Chicago", "10000 W O'Hare Ave, Chicago, IL 60666");
insert into airport (airport_id, `name`, country, city, adress) values ("LAX", "Los Angeles International Airport", "USA", "Los Angeles", "1 World Way, Los Angeles, CA 90045");
insert into airport (airport_id, `name`, country, city, adress) values ("MCO", "Orlando International Airport", "USA", "Orlando", "1 Jeff Fuqua Blvd, Orlando, FL 32827");
insert into airport (airport_id, `name`, country, city, adress) values ("CAN", "Guangzhou Baiyun International Airport", "China", "Guangzhou", "Baiyun, Guangzhou, Guangdong Province");
insert into airport (airport_id, `name`, country, city, adress) values ("CTU", "Chengdu Shuangliu International Airport", "China", "Chengdu", "Shuangliu, Chengdu, Sichuan");
insert into airport (airport_id, `name`, country, city, adress) values ("LAS", "Las Vegas McCarran International Airport", "USA", "Las Vegas", "E Sunset Rd, Las Vegas, NV 89119");

insert into airline (`name`) values ("Qatar Airways");
insert into airline (`name`) values ("Delta Air Lines");
insert into airline (`name`) values ("ANA");
insert into airline (`name`) values ("KLM");
insert into airline (`name`) values ("British Airways");
insert into airline (`name`) values ("Turkish Airlines");
insert into airline (`name`) values ("Etihad Airways");
insert into airline (`name`) values ("Singapore Airlines");
insert into airline (`name`) values ("Lufthansa");
insert into airline (`name`) values ("United Airlines");
insert into airline (`name`) values ("Air New Zealand");
insert into airline (`name`) values ("Qantas");
insert into airline (`name`) values ("Virgin Australia");
insert into airline (`name`) values ("Emirates");

create table if not exists flight(
	id int auto_increment unique not null primary key,
    airline_name varchar(32) not null,
    origin_airport_name varchar(64) not null,
    destination_airport_name varchar(64) not null,
    takeoff_time datetime not null,
    landing_time datetime not null
);

create table if not exists seat(
	id int not null auto_increment unique primary key,
	flight_id int not null,
	seat_class enum('Business', 'Economy', 'First'),
	is_booked boolean default(false) not null,
	`row` int not null,
	col char not null,
	constraint foreign key (flight_id) references flight(id) on delete cascade
);