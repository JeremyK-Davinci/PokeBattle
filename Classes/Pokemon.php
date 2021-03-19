<?php 
    class Pokemon{
        public $name;
        public $type;
        public $hitpoints;
        public $baseHitPoints;
        public $level;
        public $attacks;

        public $fainted = false;

        public function __construct($name, $type, $baseHitPoints, $level, $attacks){
            $this->name = $name;
            $this->type = $type;
            $this->baseHitPoints = $baseHitPoints;
            $this->level = $level;
            $this->hitpoints = $this->calculateHitPoints();
            $this->attacks = $attacks;
        }

        public function __toString(){
            return json_encode($this);
        }

        function calculateHitPoints(){
            $return = $this->baseHitPoints;
            for($i = 1; $i < $this->level; $i++){
                $increment = rand(1, 3);
                $return += $increment;
            }
            return $return;
        }
    }