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
    public function changeStatus($orderID, $msg)
    {
        $stmt = $this->conn->prepare("update txn set status = '" . $msg . "' where txnID = " . $orderID);
        $stmt->execute();    
    }
    public function getOrderDetails()
    {
        
    }
}
?>