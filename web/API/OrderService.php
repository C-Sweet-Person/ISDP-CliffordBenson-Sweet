<?php
session_start();
require_once '../DB/OrderAccessor.php';

$method = $_SERVER['REQUEST_METHOD'];
if ($method === "POST")
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
    //Check to see if emergency order exists (if type is emergency or order)
    //for the current store


    //Check to see if items are active if type is emergency order.
    //Else, go nuts.
    return "Null";
}

//Way to check the status of the 
function getOrders()
{
    try {
        $body = file_get_contents('php://input');
        $ic = new OrderAccessor();
        $items = $ic->getAllOrders("select * from txn");
        //$passReal = password_hash($contents['password'], PASSWORD_DEFAULT);
    //$passwords = [$user->getID(), $user->getUsername(), $user->getPassword(), $user->getEmail(), $bool];
    //$resultsA = json_encode($passwords, JSON_NUMERIC_CHECK);
        $result = json_encode($items,JSON_NUMERIC_CHECK);
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