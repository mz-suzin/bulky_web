using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using bulky_web.Data;

namespace bulky_web.Models;

public class Movie
{    
    [Key]
    public int Id { get; set; }

    public string Name { get; set; }
    public string Description { get; set; }
     public double Price { get; set; }
     public string ImageURL { get; set; }
     public DateTime StartDate { get; set; }
     public DateTime EndDate { get; set; }
     public MovieCategory MovieCategory { get; set; }

     //cinema Name, Movie Producer and Actors are relational data, so we need to first initialise the relation between those classes

     //Relationships
    public List<Actor_Movie> Actors_Movies { get; set; }

    //Cinema
    public int CinemaId { get; set; }
    [ForeignKey("CinemaId")]
    public Cinema Cinema { get; set; }

    //Producer
    public int ProducerId { get; set; }
    [ForeignKey("ProducerId")]
    public Producer Producer { get; set; }
}