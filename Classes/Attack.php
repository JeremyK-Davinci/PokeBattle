<?php
    class Attack{
        public $name;
        public $damage;
        public $type;
        public $priority;

        public function __construct($name, $damage, $type, $priority){
            $this->name = $name;
            $this->damage = $damage;
            $this->type = $type;
            $this->priority = $priority;
        }

        public function __toString(){
            return json_encode($this);
        }
    }