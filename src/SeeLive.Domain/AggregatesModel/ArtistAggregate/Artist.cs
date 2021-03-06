﻿using SeeLive.Core.Domain;
using SeeLive.Domain.Seedwork;
using System;
using System.Collections.Generic;

namespace SeeLive.Domain.AggregatesModel.ArtistAggregate
{
    public class Artist : Entity, IAggregateRoot
    {
        public Artist() { }
        public Artist(string name, string bio, string webAddress)
        {
            Name = name;
            Bio = bio;
            WebAddress = webAddress;
        }
        public string Name {get; private set;}
        public string Bio {get; private set;}
        public string WebAddress {get; private set;}
    }
}
