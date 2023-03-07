<?php
require_once 'DatabaseConnecter.php';
require_once '../DB/siteAccessor.php';

$method = $_SERVER['REQUEST_METHOD'];
if ($method === "GET")
{
        getOrders();
}
function getOrders()
{
    try {
        $body = file_get_contents('php://input');
        $ic = new OrderAccessor();
        $items = $ic->getAllOrders("select * from txn");
        $result = json_encode($ic->getAllOrders("select * from txn"),JSON_NUMERIC_CHECK);
} 
catch (PDOException $e) {
        $result = $e->getMessage();
    
}
echo $result;
}
