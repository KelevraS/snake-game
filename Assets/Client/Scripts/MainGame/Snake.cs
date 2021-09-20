using Assets.Client.Scripts.Helpers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Client.Scripts.MainGame
{
    public class Snake
    {
        private LinkedList<Cell> body = new LinkedList<Cell>();
        private Cell head;
        public Cell Head { get => head; set => head = value; }

        private ReactiveProperty<int> bodyLength = new ReactiveProperty<int>();
        public ReactiveProperty<int> BodyLength => bodyLength;

        public Snake(Cell initPos)
        {
            head = initPos;
            body.AddFirst(initPos);
            head.Type.Value = CellType.Snake;
        }

        public void Grow(Cell target)
        {
            head = target;
            head.Type.Value = CellType.Snake;
            body.AddFirst(head);

            bodyLength.Value++;
        }

        public void Move(Cell target)
        {
            body.Last.Value.Type.Value = CellType.Empty;
            body.RemoveLast();

            head = target;
            head.Type.Value = CellType.Snake;
            body.AddFirst(head);
        }

        public bool CheckCrash(Cell target)
        {
            foreach (var part in body)
                if (part.Position == target.Position)
                    return true;

            if (target.Type.Value == CellType.Border)
                return true;

            return false;
        }
    }
}