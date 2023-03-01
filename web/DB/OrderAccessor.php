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
        try{
        $stmt = $this->conn->prepare("update txn set status = '" . $msg . "' where txnID = " . $orderID);
        $stmt->execute();  
        }
        catch(Exception $ex)
        {
            $result = $ex->getMessage()
        }  finally {
            if (!is_null($stmt)) {
                $stmt->closeCursor();
            }
        }
        return $result;
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
        $result = false;
        try{
        $stmt = $this->conn->prepare("insert into txn (siteIDTo,siteIDFrom,status,shipDate,txnType,barCode,createdDate,deliveryID,emergencyDelivery) values (:NsiteIDTo,:NsiteIDFrom,:Nstatus,:NshipDate,:NtxnType,:NbarCode,GETDATE(),:NdeliveryID,:NemergencyDelivery");
        $stmt->bindParam("NsiteIDTo",$items["siteIDTo"],PDO::PARAM_INT);
        $stmt->bindParam("NsiteIDFrom",$items["siteIDFrom"],PDO::PARAM_INT);
        $stmt->bindParam("Nstaus",$items["status"],PDO::PARAM_STR);
        $stmt->bindParam("NshipDate",$items["shipDate"],PDO::PARAM_STR);
        $stmt->bindParam("NtxnType",$items["txnType"],PDO::PARAM_STR);
        $stmt->bindParam("NtxnType",$items["barCode"],PDO::PARAM_STR);
        $stmt->bindParam("NtxnType",$items["deliveryID"],PDO::PARAM_INT);
        $stmt->bindParam("NtxnType",$items["emergencyDelivery"],PDO::PARAM_BOOL);
        $stmt->execute();
        $result = true;
        }
     catch (Exception $e) {
        $result = false;
    } finally {
        if (!is_null($stmt)) {
            $stmt->closeCursor();
        }
        $result = true;
    }
    return $result;
    }

   
    /**
     * Alright, so we can use this function
     * to grab the latest txn
     * to be used RIGHT AFTER an 
     * order is created. (To add the line items).
     */
    /**
    public function GetLatestOrder()
    {

    }
     * We of course need a function
     * That will allow us to create
     * line items attached to an order.
     * Best way to do this, create a function that will
     * Take in an ID and a line.
     */
    public function createTxnItem($ID,$line,$quantity)
    {
        $stmt = $this->conn->prepare("insert into txnitems values (:OrderID, :itemID, :quantity");
        $stmt->bindParam('OrderID', $ID, PDO::PARAM_INT);
        $stmt->bindParam('itemID', $line, PDO::PARAM_INT);
        $stmt->bindParam('quantity', $quantity, PDO::PARAM_INT);
        $stmt->execute();   
    }
    /**
     * This function will just take in an order
     * And a type in order to change
     * that order's status to a particular 
     * type
     */
    public function changeType($order,$type)
    {
        try{
        $stmt = $this->conn->prepare('Update txn set txnType = ' . '"'. $type . '" ' . 'where txnID = ' . $order);
        $stmt->execute();
        }
        catch (PDOException $e) {
            echo $e->getMessage();
        }
        finally {
            if (!is_null($this->insertStatement)) {
                $stmt->closeCursor();
            }
            return $success;
        }    
    }
}
?>