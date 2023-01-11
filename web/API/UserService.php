<?php
session_start();
include '../DB/ChromePhp.php';
require_once '../DB/DatabaseConnecter.php';
require_once '../DB/UserAccessor.php';
require_once '../entities/quizResults.php';

$method = $_SERVER['REQUEST_METHOD'];
if ($method==="GET"){
    doGrabUsers();
}
if ($method === "POST" && !isset($_GET["username"]))
{
        doLogin();
}
else if($method ==="POST"){
    if (isset($_GET["username"])){
        doRegister();
    }
}
else if($method==="PUT"){
    if (isset($_GET["username"])){
        doUpdateUser();
    }
}
else if($method==="DELETE"){
    if (isset($_GET["username"])){
        doDelete();
    }
}

function doPostResults()
{
    try{
        $qra = new QuizResultAccessor();
        $body = file_get_contents('php//input');
        $contents = json_decode($body, true);
        $user = $qra->insertQuizResult(User($_GET['username'], $contents['password'], $contents['permission']));
        
    } catch (Exception $ex) {
        echo $ex;
    }
}
function doDelete() {
    if (isset($_GET['username'])) { 
        $user = $_GET['username']; 
        // delete the object from DB
        $ua = new UserAccessor();
        $dum = new User($user, "no", "USER");
        $success = $ua->deleteUser($dum);
        echo $success;
    } else {
        echo $ex;
    }
}
function doGrabUsers(){
    
        try {
            $ur = new UserAccessor();
            $results = $ur->getAllUsers();
            $results = json_encode($results, JSON_NUMERIC_CHECK);
            echo $results;
        } catch (Exception $e) {
            echo "ERROR " . $e->getMessage();
        }
}
function doUpdateUser()
{
    try {
    $body = file_get_contents('php://input');
    $contents = json_decode($body, true);
    $bool = false;
    $ua = new UserAccessor();
    $username = $contents["username"];
    $password = $contents["password"];
    $permission= $contents["permission"];
    $passReal = password_hash($contents['password'], PASSWORD_DEFAULT);
    $userPerson = new User($username,$passReal,$permission);
    $success = $ua->updateUser($userPerson); 
    if ($success){
        echo $success;
        }
    else
       {
        echo $success;
       }
} catch (PDOException $e) {
    $success = true;
    echo $e->getMessage();
}
}
function doLogin(){
    try {
        $body = file_get_contents('php://input');
        $contents = json_decode($body, true);
        $bool = false;
        ChromePhp::log($body);
        $username = $contents["username"];
        $password = $contents["password"];
        $uc = new UserAccessor();
        $user = $uc->getUserByUsername($username);
        $passReal = password_hash($contents['password'], PASSWORD_DEFAULT);
    if (password_verify($password, $user[0]->getPassword()) === true) {
        $bool = true;
    } else {
        $bool = false;
    }
    $passwords = [$passReal, $user[0]->getPassword(), $bool];
    $resultsA = json_encode($passwords, JSON_NUMERIC_CHECK);
    $success = true;
    $_SESSION["username"] = json_encode($user[0], JSON_NUMERIC_CHECK);
    $_SESSION["permission"] = json_encode($user[0]->getPermissionLevel());
} 
catch (PDOException $e) {
    echo $e->getMessage();
}
echo $success;
}

function doRegister(){
try {
    $body = file_get_contents('php://input');
    $contents = json_decode($body, true);
    $bool = false;
    $ua = new UserAccessor();
    $username = $contents["username"];
    $password = $contents["password"];
    $permission= $contents["permission"];
    $passReal = password_hash($contents['password'], PASSWORD_DEFAULT);
    $userPerson = new User($username,$passReal,$permission);
    $success = $ua->insertUser($userPerson); 
    if ($success){
        echo $success;
        }
    else
       {
        echo $success;
       }
} catch (PDOException $e) {
    $success = true;
    echo $e->getMessage();
}
} 