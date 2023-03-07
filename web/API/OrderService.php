<?php
session_start();
require_once '../DB/OrderAccessor.php';

$method = $_SERVER['REQUEST_METHOD'];
if ($method === "PUT")
{
    //Got to send in data.
        createOrder();
}
else if ($method === "GET")
{
        getOrders();
}

function createOrder()
{
    try {
        $body = file_get_contents('php://input');
        $contents = json_decode($body, true);
        $date_old = '30-6-2023 11:11:11'; 
        //Date for database
        $shippedDate = date('Y-m-d H:i:s', strtotime($date_old));
        $createdDate = date('Y-m-d H:i:s');
        $order = new transaction("dummy","1","2","Ready",$shippedDate,"Store Order",bin2hex(random_bytes(20)),$createdDate,1,0);
        $oc = new OrderAccessor();
        $result = $oc->createOrder($order,"Store Order");

} 
catch (PDOException $e) {
        $result = $e->getMessage();
    
}
echo $result;
}

//Way to check the status of the 
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

function checkStatus()
{
    return "Null";
}