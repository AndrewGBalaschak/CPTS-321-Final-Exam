# CPTS321-Fall2023 Final Exam

## Features
- **Pages:**
    - **Login/authetication page**
    - **Accounts page**
    - **New transfer page**
    - **Dispute transfer page**
- **Data Objects:**
    - **User**
        - **Clients**
        - **Employees**
    - **Account**
        - **Checking**
        - **Savings**
    - **Transfer**
- **Database Objects:**
    - **UserManager** - in charge of maintaining Users database.
    - **AccountManager** - in charge of maintaining Accounts database.
    - **TranferManager** - in charge of maintaining Transfers database.
- **Other Features:**
    - General error handing and friendly error message popups.
    - Base objects are "dumb" and all management and modification is done with UserManager, AccountManager, and TransferManager.
        - Database style management, with Users, Accounts, and Transfers managed by separate Manager classes. Will make it easy to switch to a DBMS for proper implementation.
    - Heirarchical structure, UserManager interacts with AccountManager which interacts with TransferManager