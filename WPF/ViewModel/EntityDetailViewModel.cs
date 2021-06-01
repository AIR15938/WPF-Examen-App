using Prism.Commands;
using Prism.Events;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF.Model;
using WPF.Services;
using WPF.Event;
using WPF.Repositories;

namespace WPF.ViewModel
{
    public class EntityDetailViewModel : ViewModelBase, IEntityDetailViewModel
    {
        private IEntityRepository _entityRepository;
        private IEventAggregator _eventAggregator;
        private Entity _entity;
        private TrackRecord _selectedTrackRecord;
        private bool _hasChanges;
        private IMessageDialog _messageDialog;

        public ICommand SaveCommand { get; }
        public ICommand DeleteCommand { get; }

        public ICommand AddTrackRecordCommand { get; }

        public ICommand RemoveTrackRecordCommand { get; }

        public ObservableCollection<TrackRecord> TrackRecords { get; }

        public EntityDetailViewModel(IEntityRepository entityRepository, IEventAggregator eventAggregator, IMessageDialog messageDialog)
        {
            _entityRepository = entityRepository;
            _eventAggregator = eventAggregator;
            _messageDialog = messageDialog;

            SaveCommand = new DelegateCommand(OnSaveExecute);/*, OnSaveCanExecute);*/
            DeleteCommand = new DelegateCommand(OnDeleteExecute);

            //AddTrackRecordCommand = new DelegateCommand(OnAddTrackRecordExecute);
            //RemoveTrackRecordCommand = new DelegateCommand(OnRemoveTrackRecordExecute, OnRemoveTrackRecordCanExecute);
        }


        public async Task LoadAsync(int? entityId)
        {
            var entity = entityId.HasValue
              ? await _entityRepository.GetByIdAsync(entityId.Value)
              : CreateNewEntity();
         }

        public Entity Entity
        {
            get { return _entity; }
            private set
            {
                _entity = value;
                OnPropertyChanged();
            }
        }

        public bool HasChanges
        {
            get { return _hasChanges; }
            set
            {
                if (_hasChanges != value)
                {
                    _hasChanges = value;
                    OnPropertyChanged();
                    ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
                }
            }
        }



        private async void OnSaveExecute()
        {
            await _entityRepository.SaveAsync();
            HasChanges = _entityRepository.HasChanges();
            _eventAggregator.GetEvent<EntitySavedEvent>().Publish(
              new EntitySavedEventArgs
              {
                  Id = Entity.Id,
                  DisplayMember = $"{Entity.Name}"
              });
        }

        //private bool OnSaveCanExecute()
        //{
        //    return Entity != null && HasChanges;
        //}

        private async void OnDeleteExecute()
        {
            var result = _messageDialog.ShowOkCancelDialog($"Are you sure you want to delete {Entity.Name} ?",
              "Question");
            if (result == MessageDialog.MessageDialogResult.OK)
            {
                _entityRepository.Remove(Entity);
                await _entityRepository.SaveAsync();
                _eventAggregator.GetEvent<EntityDeletedEvent>().Publish(Entity.Id);
            }
        }

        private Entity CreateNewEntity()
        {
            var entity = new Entity();
            _entityRepository.Add(entity);
            return entity;
        }

        public TrackRecord SelectedTrackRecord
        {
            get { return _selectedTrackRecord; }
            set
            {
                _selectedTrackRecord = value;
                OnPropertyChanged();
                ((DelegateCommand)RemoveTrackRecordCommand).RaiseCanExecuteChanged();
            }
        }

        //private void OnAddTrackRecordExecute()
        //{
        //    var newTrackRecord = new TrackRecord);
        //    TrackRecord.Add(newTrackRecord)
        //}
    }
}
