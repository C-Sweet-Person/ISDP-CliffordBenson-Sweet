<?php
require_once '../DB/siteAccessor.php';

$method = $_SERVER['REQUEST_METHOD'];
if ($method === "GET")
{
        getSites();
}
function getSites()
{
    try {
        $body = file_get_contents('php://input');
        $sa = new siteAcessor();
        $result = json_encode($sa->getSites("select * from site"),JSON_NUMERIC_CHECK);
} 
catch (PDOException $e) {
        $result = $e->getMessage();
}
echo $result;
}
