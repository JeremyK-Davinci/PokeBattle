<?php 
    class Pokemon{
        public $name;
        public $type;
        public $hitPoints;
        public $maxHitpoints;
        public $baseHitPoints;
        public $level;
        public $attacks;

        public $fainted = false;

        public function __construct($name, $type, $baseHitPoints, $level, $attacks){
            $this->name = $name;
            $this->type = $type;
            $this->baseHitPoints = $baseHitPoints;
            $this->level = $level;
            $this->hitPoints = $this->calculateHitPoints();
            $this->maxHitPoints = $this->hitPoints;
            $this->attacks = $attacks;
        }

        public function __toString(){
            return json_encode($this);
        }

        public function __getTypeFromMyId(){
            return $Types[$this->type];
        }

        public function __calculateNewHitPoints(){
            $increment = rand(1, 3);
            $this->hitPoints += $increment;
            $this->maxHitPoints = $this->hitPoints;
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