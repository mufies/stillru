/* src/pages/Index.jsx */
import { useState, useEffect, useRef } from "react";
import Navigator from "../compoment/Navigator";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faPlay, faPause } from "@fortawesome/free-solid-svg-icons";
import "./main.css";

const STREAM_URL = "https://listen.moe/stream";
const WS_URL     = "wss://listen.moe/gateway_v2";

export default function Index() {
    /* play / pause */
    const [isPlaying, setIsPlaying] = useState(false);
    const audioRef = useRef<HTMLAudioElement | null>(null);

    /* track info */
    const [song, setSong] = useState({
        title: "",
        artist: "",
        cover: "",
    });

    /* toggle playback */
    useEffect(() => {
        const audio = audioRef.current as HTMLAudioElement | null;
        if (!audio) return;

        if (isPlaying) {
            audio.play().catch((err: Error) => console.error("Audio play error:", err));
        } else {
            audio.pause();
        }
    }, [isPlaying]);

    /* WebSocket metadata */
    useEffect(() => {
        const ws = new WebSocket(WS_URL);

        ws.onmessage = evt => {
            try {
                const msg = JSON.parse(evt.data);
                if (msg.op === 1 && msg.t === "TRACK_UPDATE" && msg.d?.song) {
                    const { title, artists, covers } = msg.d.song;
                    setSong({
                        title,
                        artist: artists?.[0]?.name ?? "Unknown",
                        cover: covers?.small || covers?.large || null
                    });
                }
            } catch (err) {
                console.error("WS parse error", err);
            }
        };

        return () => ws.close();
    }, []);

    /* UI */
    return (
        <div>
            <Navigator />

            <div className="flex w-screen pl-80 pb-10">
                <h1 className="text-3xl font-bold">スチィルインラブ</h1>
            </div>

            <div className="radio-container flex pl-80 w-screen">
                <button
                    className="bg-transparent w-20 h-20 flex items-center justify-center mr-5 rounded-lg"
                    onClick={() => setIsPlaying(!isPlaying)}
                >
                    <FontAwesomeIcon
                        icon={isPlaying ? faPause : faPlay}
                        className="text-3xl text-white"
                    />
                </button>

                <div className="flex items-center w-200 h-20 bg-transparent mr-5 rounded-lg  ">


                    <div className="flex flex-col justify-center pl-3">
                        <h2 className="text-l">{song.title || "Loading…"}</h2>
                        <h2 className="text-l">Artist: {song.artist}</h2>
                    </div>
                    {song.cover && (
                        <img
                            src={song.cover}
                            alt={song.title}
                            className="w-16 h-16 object-cover rounded-l-lg"
                        />
                    )}
                </div>

                {/* hidden audio element */}
                <audio ref={audioRef} src={STREAM_URL} />
            </div>
        </div>
    );
}
