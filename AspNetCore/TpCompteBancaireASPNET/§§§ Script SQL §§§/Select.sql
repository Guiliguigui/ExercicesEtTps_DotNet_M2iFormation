SELECT cb.Id, cb.nom, cb.prenom, cb.telephone, c.solde, c.taux, c.coutOperation FROM compte as c
INNER JOIN clientCompte AS cc ON c.Id = cc.Idcompte
INNER JOIN clientBanque AS cb ON cc.IdClient = cb.Id
SELECT * FROM compte;
SELECT * FROM clientCompte;
SELECT * FROM clientBanque;