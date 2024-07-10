using Application.SearchEngine.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SearchEngine.QueriesHandler
{
    public class GetSearchResultQueryHandler : IRequestHandler<GetSearchResultQuery, OperationResult<List<SearchResult>>>
    {
        private readonly DataContext _ctx;
        private readonly OperationResult<List<SearchResult>> _result = new OperationResult<List<SearchResult>>();
        public GetSearchResultQueryHandler(DataContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<OperationResult<List<SearchResult>>> Handle(GetSearchResultQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var searchResultList = new List<SearchResult>();
                var artists = await _ctx.Artists.Where(a => a.Name.Contains(request.SearchItem)).ToListAsync();
                
                foreach (var artist in artists) {
                    var searchedArtist = SearchResult.CreateSearchResult(artist, "Artist");
                    searchResultList.Add(searchedArtist);
                }

                var albums = await _ctx.Albums.Where(a => a.Title.Contains(request.SearchItem)).ToListAsync();

                foreach (var album in albums)
                {
                    var searchedAlbum = SearchResult.CreateSearchResult(album, "Album");
                    searchResultList.Add(searchedAlbum);
                }

                var songs = await _ctx.Songs.Where(a => a.Title.Contains(request.SearchItem)).ToListAsync();

                foreach (var song in songs)
                {
                    var searchedSong = SearchResult.CreateSearchResult(song, "Song");
                    searchResultList.Add(searchedSong);
                }

                _result.Payload = searchResultList;
            }
            catch (Exception ex)
            {
                _result.AddUnknownError(ex.Message);
            }

            return _result;
        }
    }
}
