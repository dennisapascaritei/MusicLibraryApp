import { Song } from "./songs"

export class Album {
    albumId: string = ""
    title: string = ""
    description: string = ""
    artistId: string = ""
    songs: Song[] = []
}