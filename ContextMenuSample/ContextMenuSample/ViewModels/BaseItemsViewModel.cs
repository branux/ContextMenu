﻿using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace ContextMenuSample.ViewModels
{
    public class BaseItemsViewModel : BaseViewModel
    {
        private ICommand _deleteCommand;
        public ICommand DeleteCommand => _deleteCommand ?? (_deleteCommand = new Command(item =>
        {
            Items.Remove(item as Item);
        }));

        private ICommand _muteCommand;
        public ICommand MuteCommand => _muteCommand ?? (_muteCommand = new Command(item =>
        {
            var model = item as Item;
            model.IsMuted = !model.IsMuted;
        }));

        public ObservableCollection<Item> Items { get; } = new ObservableCollection<Item>
        {
            new Item
            {
                AvatarUrl = "https://pbs.twimg.com/profile_images/812310411647205376/gxleSqEg_400x400.jpg",
                Name = "David Ortinau"
            },
            new Item
            {
                AvatarUrl = "https://secure.gravatar.com/avatar/048050ef65ec9aa188c662ae1895ecc7?s=400&d=mm&r=g",
                Name = "James Montemagno"
            },
            new Item
            {
                AvatarUrl = "https://avatars0.githubusercontent.com/u/10124814?s=400&v=4",
                Name = "Andrei Misiukevich"
            },
            new Item
            {
                AvatarUrl = "https://avatars2.githubusercontent.com/u/7827070?s=460&v=4",
                Name = "Samantha Houts"
            }
        };

        public BaseItemsViewModel()
        {
            foreach (var item in Enumerable.Range(0, 10).Select(x => new Item
            {
                AvatarUrl = "https://steemitimages.com/640x0/https://botlist.co/system/BotList/Bot/logos/000/003/817/medium/Quriobot-chatbot.jpg",
                Name = $"BOT {x}"
            }))
            {
                Items.Add(item);
            }
        }

        public sealed class Item : BaseViewModel
        {
            private string _avatarUrl;
            private string _name;
            private bool _isMuted;

            public string AvatarUrl
            {
                get => _avatarUrl;
                set
                {
                    _avatarUrl = value;
                    OnPropertyChanged();
                }
            }

            public string Name
            {
                get => _name;
                set
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
            public bool IsMuted
            {
                get => _isMuted;
                set
                {
                    _isMuted = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
