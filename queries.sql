create table "Bands" (
  "Id" Serial Primary Key,
  "Name" Text,
  "CountryOfOrigin" Text,
  "NumberOfMembers" Integer,
  "Website" Text,
  "Genre" Text,
  "IsSigned" Boolean,
  "ContactName" Text
  );


create table "Albums" (
  "Id" serial primary key,
  "Title" text,
  "IsExplicit" boolean,
  "ReleaseDate" date,
  "BandId" Integer null references "Bands"("Id")
  );


create table "Songs" (
  "Id" serial primary key,
  "TrackNumber" integer,
  "Title" text,
  "Duration" text,
  "AlbumId" Integer null references "Albums" ("Id")
  );