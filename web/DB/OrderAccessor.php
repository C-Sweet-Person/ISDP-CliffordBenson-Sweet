<?php
require_once 'DatabaseConnecter.php';
require_once '../Entity/User.php';

class OrderAccessor
{
    private $conn = NULL;
    public function __construct()
    {
        $cm = new Connector();

        $this->conn = $cm->connect_db();
        if (is_null($this->conn)) {
            throw new Exception("no connection");
        }
    }
    public function getAllOrders($selectString)
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
    public function deleteOrder()
    {
        
    }
    public function getOrderDetails()
    {
        
    }
}
?>