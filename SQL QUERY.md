# Labb3Gymnasieskola

--Hämta ut personal (ska lösas med SQL)--
SELECT * FROM tblPersonal

SELECT * FROM tblPersonal
Where Befattning = 'Lärare'

--Hämta ut alla betyg som sats senaste månaden (ska lösas med SQL)--
SELECT KursNamn, Betyg, Förnamn + ' ' +  Efternamn as Namn, Datum 
from tblBetyg
inner join tblElev on tblElev.ElevId = tblBetyg.ElevId
inner join tblKurs on tblKurs.KursId = tblBetyg.KursId
Where 
Datum > DATEADD(MONTH, -1,GETDATE())

--Hämta ut en lista med alla kurser och det snittbetyg som eleverna fått på den kursen samt det högsta och lägsta betyget som någon fått i kursen (ska lösas med SQL)--
SELECT KursNamn, AVG(BetygSiffra) as Snittbetyg, MAX(BetygSiffra) as Högstabetyg, MIN(BetygSiffra) as Lägstabetyg
from tblBetyg
inner join tblKurs on tblKurs.KursId = tblBetyg.KursId
group by KursNamn


--Lägga till nya elever (ska lösas genom SQL)--
INSERT INTO tblElev(Personnummer,Förnamn,Efternamn,Klass)
VALUES ('930409-8689','Robin','Claesson','SUT22')
