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
        getOrder();
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
function getOrder()
{
    return "Null";
}
function getOrders()
{
    //Bulk checking of orders
    //In case one needs to do that.
}

function checkStatus()
{
    return "Null";
}