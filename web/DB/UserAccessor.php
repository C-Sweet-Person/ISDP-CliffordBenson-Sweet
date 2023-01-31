<?php
require_once 'DatabaseConnecter.php';
require_once '../Entity/User.php';
/*
Half of this code is from my QuizAPP page.
Future versions will remove that old code.
Hopefully can make this look better.
*/
class UserAccessor {

    private $getByIDStatementString = "select * from employee where username = :user";
    private $deleteStatementString = "delete from QuizAppUser where username = :user";
    private $insertStatementString = "insert INTO QuizAppUser values (:user, :pass, :perm)";
    private $updateStatementString = "update QuizAppUser set password = :pass, permissionLevel = :perm where username = :user";
    private $conn = NULL;
    private $getByIDStatement = NULL;
    private $deleteStatement = NULL;
    private $insertStatement = NULL;
    private $updateStatement = NULL;

    // Constructor will throw exception if there is a problem with ConnectionManager,
    // or with the prepared statements.
    public function __construct() {
        $cm = new Connector();

        $this->conn = $cm->connect_db();
        if (is_null($this->conn)) {
            throw new Exception("no connection");
        }
        $this->getByIDStatement = $this->conn->prepare($this->getByIDStatementString);
        if (is_null($this->getByIDStatement)) {
            throw new Exception("bad statement: '" . $this->getAllStatementString . "'");
        }

        $this->deleteStatement = $this->conn->prepare($this->deleteStatementString);
        if (is_null($this->deleteStatement)) {
            throw new Exception("bad statement: '" . $this->deleteStatementString . "'");
        }

        $this->insertStatement = $this->conn->prepare($this->insertStatementString);
        if (is_null($this->insertStatement)) {
            throw new Exception("bad statement: '" . $this->getAllStatementString . "'");
        }

        $this->updateStatement = $this->conn->prepare($this->updateStatementString);
        if (is_null($this->updateStatement)) {
            throw new Exception("bad statement: '" . $this->updateStatementString . "'");
        }
    }

    /**
     * Gets menu items by executing a SQL "select" statement. An empty array
     * is returned if there are no results, or if the query contains an error.
     * 
     * @param String $selectString a valid SQL "select" statement
     * @return array MenuItem objects
     */
    private function getUsersByQuery($selectString) {
        $result = [];

        try {
            $stmt = $this->conn->prepare($selectString);
            $stmt->execute();
            $dbresults = $stmt->fetchAll(PDO::FETCH_ASSOC);

            foreach ($dbresults as $r) {
                $user = $r['username'];
                $pass = $r['password'];
                $perm = $r['permissionLevel'];
                
                $obj = new User($user, $pass, $perm);
                array_push($result, $obj);
            }
        }
        catch (Exception $e) {
            $result = [];
        }
        finally {
            if (!is_null($stmt)) {
                $stmt->closeCursor();
            }
        }

        return $result;
    }

    /**
     * Gets all menu items.
     * 
     * @return array MenuItem objects, possibly empty
     */
    
    public function getAllUsers() {
        return $this->getUsersByQuery("select * from QuizAppUser");
    }

    /**
     * Gets the menu item with the specified ID.
     * 
     * @param Integer $id the ID of the item to retrieve 
     * @return the MenuItem object with the specified ID, or NULL if not found
     */
    public function getUserByUsername($user) {
        $result = [];

        try {
            $this->getByIDStatement->bindParam(":user", $user);
            $this->getByIDStatement->execute();
            $dbresults = $this->getByIDStatement->fetch(PDO::FETCH_ASSOC); // not fetchAll

            if ($dbresults) {
                $ID = $dbresults['employeeID'];
                $user = $dbresults['username'];
                $pass = $dbresults['password'];
                $firstName = $dbresults['employeeID'];
                $lastName = $dbresults['employeeID'];
                $email = $dbresults['email'];
                $active = $dbresults['active'];
                $locked = $dbresults['locked'];
                $positionID = $dbresults['positionID'];
                $siteID = $dbresults['siteID'];
                $usern = new User($ID, $user, $pass,$firstName,$lastName,$email,$active,$locked,$positionID,$siteID);
                array_push($result, $usern);
            }
        }
        catch (Exception $e) {
            $result = NULL;
        }
        finally {
            if (!is_null($this->getByIDStatement)) {
                $this->getByIDStatement->closeCursor();
            }
        }
        return $result;
    }

    /**
     * Deletes a menu item.
     * @param MenuItem $item an object whose ID is EQUAL TO the ID of the item to delete
     * @return boolean indicates whether the item was deleted
     */
    public function deleteUser($item) {
        $success = false;

        $useID = $item->getUsername(); // only the ID is needed

        try {
            $this->deleteStatement->bindParam(":user", $useID);
            $success = $this->deleteStatement->execute(); // this doesn't mean what you think it means
            $rc = $this->deleteStatement->rowCount();
        }
        catch (PDOException $e) {
            $success = false;
        }
        finally {
            if (!is_null($this->deleteStatement)) {
                $this->deleteStatement->closeCursor();
            }
            return $success;
        }
    }

    /**
     * Inserts a menu item into the database.
     * 
     * @param MenuItem $item an object of type MenuItem
     * @return boolean indicates if the item was inserted
     */
    public function insertUser($new) {
        $success = false;

        $username = $new->getUsername();
        $pass = $new->getPassword();
        $perms = $new->getPermissionLevel();

        try {
            $this->insertStatement->bindParam(":user", $username);
            $this->insertStatement->bindParam(":pass", $pass);
            $this->insertStatement->bindParam(":perm", $perms);
            $success = $this->insertStatement->execute();// this doesn't mean what you think it means
        }
        catch (PDOException $e) {
            echo $e->getMessage();
        }
        finally {
            if (!is_null($this->insertStatement)) {
                $this->insertStatement->closeCursor();
            }
            return $success;
        }
    }

    /**
     * Updates a menu item in the database.
     * 
     * @param MenuItem $item an object of type MenuItem, the new values to replace the database's current values
     * @return boolean indicates if the item was updated
     */
    public function updateUser($new) {
        $success = false;

        $username = $new->getUsername();
        $pass = $new->getPassword();
        $perms = $new->getPermissionLevel();

        try {
            $this->updateStatement->bindParam(":user", $username);
            $this->updateStatement->bindParam(":pass", $pass);
            $this->updateStatement->bindParam(":perm", $perms);
            $success = $this->updateStatement->execute();// this doesn't mean what you think it means
        }
        catch (PDOException $e) {
            $success = false;
        }
        finally {
            if (!is_null($this->updateStatement)) {
                $this->updateStatement->closeCursor();
            }
            return $success;
        }
    }

}
