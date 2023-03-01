<?php
session_start();
require_once '../DB/inventoryAccessor.php';

$method = $_SERVER['REQUEST_METHOD'];
if ($method === "GET")
{
        grabInventory();
}
function grabInventory(){
    try {
        $body = file_get_contents('php://input');
        $ic = new inventoryAccessor();
        $items = $ic->getAllInventoryItems();
        $result = json_encode($items,JSON_NUMERIC_CHECK);
} 
catch (PDOException $e) {
        echo $e->getMessage();
    
}
//echo json_encode($ic->getInventoryItems("select * from item"), JSON_NUMERIC_CHECK);
echo json_encode($ic->getAllInventoryItems(), JSON_NUMERIC_CHECK);

}