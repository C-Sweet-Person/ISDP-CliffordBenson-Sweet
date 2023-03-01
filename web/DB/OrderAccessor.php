<?php
require_once 'DatabaseConnecter.php';
require_once '../Entity/transaction.php';
require_once "../Entity/txnLineItem.php";

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
        catch (PDOException $ex) {
            $result = $ex->getMessage();
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
 * This function checks for the list
 * of line items created with an order
 * and sends it to the client.
 */
public function getLineItems($ID)
{
    $result = [];
    try {
        $stmt = $this->conn->prepare("select * from txnitems where txnID = :ID");
        $stmt->bindParam(":ID",$ID);
        $stmt->execute();
        $dbresults = $stmt->fetchAll(PDO::FETCH_ASSOC);
        foreach ($dbresults as $r)
        {
            $txnID = $r["txnID"];
            $itemID = $r["itemID"];
            $quantity = $r["quantity"];
            $line = new txnLineItem($txnID,$itemID,$quantity);
            array_push($result,$line);
        }
    }
    catch (PDOException $ex)
    {
        $result = $ex->getMessage();
    } finally {
        if (!is_null($stmt))
        {
            $stmt->closeCursor();
        }
    }
    return $result;
    }


    /**
     * This function creates an
     * order using a specified order type and
     * takes in a list to create txnLine items after the
     * actual order is created.
     */
    public function createOrder($txn,$type)
    {
        $result = false;
        $siteIDTO = $txn->getSiteIDTo();
        $siteIDFrom = $txn->getSiteIDFrom();
        $status = $txn->getStatus();
        $shippedDate = $txn->getShipDate();
        $txnType = $txn->getType();
        $barcode = $txn->getBarCode();
        $deliveryID = $txn->getDeliveryID();
        $emergency = $txn->isEmergencyOrder();


        try{
        $stmt = $this->conn->prepare("insert into txn (siteIDTo,siteIDFrom,status,shipDate,txnType,barCode,createdDate,deliveryID,emergencyDelivery) values (:NsiteIDTo,:NsiteIDFrom,:Nstatus,:NshipDate,:NtxnType,:NbarCode,NOW(),:NdeliveryID,:NemergencyDelivery)");
        $stmt->bindParam(":NsiteIDTo",$siteIDTO);
        $stmt->bindParam(":NsiteIDFrom",$siteIDFrom);
        $stmt->bindParam(":Nstatus",$status);
        $stmt->bindParam(":NshipDate",$shippedDate);
        $stmt->bindParam(":NtxnType",$txnType);
        $stmt->bindParam(":NbarCode",$barcode);
        $stmt->bindParam(":NdeliveryID",$deliveryID);
        $stmt->bindParam(":NemergencyDelivery",$emergency);
        $stmt->execute();
        $stmt->rowCount();
        if ($stmt->rowCount() > 0)
        {
            $result = true;
        }
        else
        {
            $result = false;
        }
        }
        catch (PDOException $ex) {
        $result = $ex->getMessage();
    } finally {
        if (!is_null($stmt)) {
            $stmt->closeCursor();
        }
    }
    return $result;
    }

   
    /*
     * Alright, so we can use this function
     * to grab the latest txn
     * to be used RIGHT AFTER an 
     * order is created. (To add the line items).
     */

    public function GetLatestOrderID()
    {
        $result = null;
        try{
        $stmt = $this->conn->prepare("select txnID from txn order by txnID desc");
        }
        catch (PDOException $ex)
        {
            $result = $ex->getMessage();
        }
    finally {
        if (!is_null($stmt)) {
            $stmt->closeCursor();
        }
        $result = true;
    }
    echo $result;

    }
     /* We of course need a function
     * That will allow us to create
     * line items attached to an order.
     * Best way to do this, create a function that will
     * Take in an ID and a line.
     */
    public function createTxnItem($ID,$line,$quantity)
    {
        $result = null;
        try{
        $stmt = $this->conn->prepare("insert into txnitems values (:OrderID, :itemID, :quantity");
        $stmt->bindParam('OrderID', $ID, PDO::PARAM_INT);
        $stmt->bindParam('itemID', $line, PDO::PARAM_INT);
        $stmt->bindParam('quantity', $quantity, PDO::PARAM_INT);
        $stmt->execute(); 
        $result = true;
        }
        catch(PDOException $ex)
        {
            $result = $ex->getMessage();
        }
        finally {
            if (!is_null($stmt)) {
                $stmt->closeCursor();
            }
            return $result;
        }  
      
    }
    /**
     * This function will just take in an order
     * And a type in order to change
     * that order's status to a particular 
     * type
     */
    public function changeType($order,$type)
    {
        $result = null;
        try{
        $stmt = $this->conn->prepare('Update txn set txnType = ' . '"'. $type . '" ' . 'where txnID = ' . $order);
        $stmt->execute();
        }
        catch (PDOException $e) {
            return $result = $e->getMessage();
        }
        finally {
            if (!is_null($stmt)) {
                $stmt->closeCursor();
            }
            return $result;
        }    
    }
}
?>