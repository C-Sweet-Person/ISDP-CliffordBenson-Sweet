<?php
class txnLineItem implements JSONSerializable
{
private $txnID;
private $ItemID;
private $quantity;

public function __construct($txnID,$ItemID,$quantity)
{
$this->txnID = $txnID;
$this->ItemID = $ItemID;
$this->quantity = $quantity;

}
public function getID()
{
    return $this->txnID;
}
public function getItemID()
{
    return $this->ItemID;
}
public function getQuantity()
{
    return $this->quantity;
}
public function jsonSerialize() {
    return get_object_vars($this);
}
}