<?php
require_once 'DatabaseConnecter.php';
require_once '../Entity/transaction.php';

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
    /*
    This function is used
    to get all the orders with a custom
    select string.
    */
    public function getAllOrders($selectString)
    {
        $result = [];

        try {
            $stmt = $this->conn->prepare($selectString);
            $stmt->execute();
            $dbresults = $stmt->fetchAll(PDO::FETCH_ASSOC);
//( $itemID, $name, $description,$category,$weight,$costPrice,$retailPrice,$supplierID,$active,$notes,$caseSize) 
            foreach ($dbresults as $r) {
                $txnID = $r['txnID'];
                $siteIDTo = $r['siteIDTo'];
                $siteIDFrom = $r['siteIDFrom'];
                $status = $r['status'];
                $shipDate = $r['shipDate'];
                $txnType = $r['txnType'];
                $barCode = $r['barCode'];
                $createdDate = $r['createdDate'];
                $deliveryID = $r['deliveryID'];
                $emergencyDelivery = $r['emergencyDelivery'];
                $txn = new transaction( $txnID, $siteIDTo, $siteIDFrom,$status,$shipDate,$txnType,$barCode,$createdDate,$deliveryID,$emergencyDelivery);
                array_push($result, $txn);
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
    //
    //
    //
    //

    public function changeStatus($orderID, $msg)
    {
        $stmt = $this->conn->prepare("update txn set status = '" . $msg . "' where txnID = " . $orderID);
        $stmt->execute();    
    }
    /**
     * This function is used
     * to get the order types, but only for ones that can be specfically created.
     */
    public function getOrderDetails()
    {
        
    }
    /**
     * This function creates an
     * order using a specified order type and
     * takes in a list to create txnLine items after the
     * actual order is created.
     */
    public function createOrder($items,$type)
    {
        $stmt = $this->conn->prepare($selectString);
        $stmt->execute();
        $dbresults = $stmt->fetchAll(PDO::FETCH_ASSOC);  
    }
    /**
     * This function will just take in an order
     * And a type in order to change
     * that order's status to a particular 
     * type
     */
    public function changeType($order,$type)
    {
        
    }
}
?>