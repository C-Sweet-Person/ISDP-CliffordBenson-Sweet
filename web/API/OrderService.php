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

} 
catch (PDOException $e) {
        $result = $e->getMessage();
    
}
echo $contents[0]["itemName"] . $contents[1]["itemName"];
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