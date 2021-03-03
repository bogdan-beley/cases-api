# Cases API

## Task:
1. database structure
  * incidents  accounts  contacts
  * incident -> account, 1=>M,
  * account -> contact , 1=> M
  * Incident,  incident name - primary key, autogenerated, string
  * Account, Name - > unique string field
2. create web api, asp core, ef code first (edited) 
3. methods to create, contacts, accounts, incidents (edited) 
4. account cannot be created without contact
5. case cannot be created without account
6. logic for incident creation method
  * request body
  
        {
            account name,
            contact first name,
            contact last name,
            contact email, -> unique identifier,
            incident description,
        }
        
  * if account name is not in the system, -> return 404
  * if contact is in the system (check by email), update contact record, link to account if not linked
  * if not, create new contact with first name, last name, email and link to the account
7. create new case, for account and populate description
