<?php
require_once 'DatabaseConnecter.php';
require_once '../Entity/inventory.php';
require_once '../Entity/inventoryStore.php';

require_once '../DB/itemAccessor.php';



class inventoryAccessor
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
/**This function grabs the inventory items
 * by site.
 */
 public function getAllInventoryBySiteWithPrice($id)
 {
    $ia = new itemAccessor();
    $result = [];
    try
    {
     $stmt = $this->conn->prepare("select distinct i.itemID, i.siteID, i.quantity, item.category,i.itemLocation,i.reorderThreshold,item.retailPrice from inventory i join
     item on i.itemID = item.itemID where siteID = :thisID order by i.itemID asc");
     $stmt->bindParam(':thisID', $id);
     $stmt->execute();
     $dbresults = $stmt->fetchAll();
     foreach($dbresults as $r)
     {
        $itemID = $r["itemID"];
        $siteID = $r["siteID"];
        $quantity = $r["quantity"];
        $category = $r["category"];
        $itemLocation = $r["itemLocation"];
        $reorderThreshold = $r["reorderThreshold"];
        $retailPrice = $r["retailPrice"];
        $itemName = $ia->getItemNameByID($r["itemID"]);
        $inventoryItem = new inventoryStore($itemID,$itemName,$category,$siteID,$quantity,$itemLocation,$reorderThreshold,$retailPrice);
        array_push($result,$inventoryItem);
     }

    }
    catch (PDOException $ex)
    {
     $result = $ex->getMessage();
    } 
    finally {
     if (!is_null($stmt)) {
         $stmt->closeCursor();
     }
 }
 return $result;  
 }
/**
 * This function gets
 * All the inventory items,
 * no matter if they're empty
 * or not.
 */
    public function getAllInventoryItems()
    {
    $ia = new itemAccessor();
       $result = [];
       try
       {
        $stmt = $this->conn->prepare("select * from inventory");
        $stmt->execute();
        $dbresults = $stmt->fetchAll();
        foreach($dbresults as $r)
        {
           $itemID = $r["itemID"];
           $siteID = $r["siteID"];
           $quantity = $r["quantity"];
           $itemLocation = $r["itemLocation"];
           $reorderThreshold = $r["reorderThreshold"];
           $itemName = $ia->getItemNameByID($r["itemID"]);
           $inventoryItem = new inventory($itemID,$itemName,$siteID,$quantity,$itemLocation,$reorderThreshold);
           array_push($result,$inventoryItem);

        }

       }
       catch (PDOException $ex)
       {
        $result = $ex->getMessage();
       } 
       finally {
        if (!is_null($stmt)) {
            $stmt->closeCursor();
        }
    }
    return $result;
    }
}