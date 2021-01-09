using Leopotam.Ecs;
using UnityEngine;

namespace TicToe
{
    internal class CreateCellViewSystem : IEcsRunSystem
    {
        //получить все компоненты на которых есть Cell и Position
        private EcsFilter<Cell, Position>.Exclude<CellViewRef> _filter;
        private Configuration _configuration;

        public void Run()
        {
            //форычем проходим по всему фильтру, получаем индекс этого массива, чтобы получить значение компонента
            foreach (var index in _filter)
            {
                ref var position = ref _filter.Get2(index);

                var cellView = Object.Instantiate(_configuration.CellView);

                cellView.transform.position = new Vector3(position.value.x + _configuration.Offset.x * position.value.x, 
                                                            position.value.y + _configuration.Offset.y * position.value.y);

                cellView.Entity = _filter.GetEntity(index);

                _filter.GetEntity(index).Get<CellViewRef>().value = cellView;
            }
        }
    }
}