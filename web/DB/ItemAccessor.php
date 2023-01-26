<?php
require_once 'DatabaseConnecter.php';
require_once '../Entity/item.php';


class itemAccessor
{

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
    public function __construct()
    {
        $cm = new Connector();

        $this->conn = $cm->connect_db();
        if (is_null($this->conn)) {
            throw new Exception("no connection");
        }
        $this->getByIDStatement = $this->conn->prepare($this->getByIDStatementString);
        if (is_null($this->getByIDStatement)) {
            throw new Exception("bad statement: '" . $this->getByIDStatement . "'");
        }

    }

    /**
     * Gets menu items by executing a SQL "select" statement. An empty array
     * is returned if there are no results, or if the query contains an error.
     * 
     * @param string $selectString a valid SQL "select" statement
     * @return array MenuItem objects
     */
    public function getInventoryItems($selectString)
    {
        $result = [];

        try {
            $stmt = $this->conn->prepare($selectString);
            $stmt->execute();
            $dbresults = $stmt->fetchAll(PDO::FETCH_ASSOC);
//( $itemID, $name, $description,$category,$weight,$costPrice,$retailPrice,$supplierID,$active,$notes,$caseSize) 
            foreach ($dbresults as $r) {
                $itemID = $r['itemID'];
                $name = $r['name'];
                $description = $r['description'];
                $category = $r['category'];
                $weight = $r['weight'];
                $costPrice = $r['costPrice'];
                $retailPrice = $r['retailPrice'];
                $supplierID = $r['supplierID'];
                $active = $r['active'];
                $notes = $r['notes'];
                $caseSize = $r['caseSize'];
                $item = new item( $itemID, $name, $description,$category,$weight,$costPrice,$retailPrice,$supplierID,$active,$notes,$caseSize);
                array_push($result, $item);
            }
        } catch (Exception $e) {
            $result = [];
        } finally {
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

    public function getAllUsers()
    {
        return $this->getUsersByQuery("select * from QuizAppUser");
    }

/**
 * Gets the menu item with the specified ID.
 * 
 * @param Integer $id the ID of the item to retrieve 
 * @return the MenuItem object with the specified ID, or NULL if not found
 */
}