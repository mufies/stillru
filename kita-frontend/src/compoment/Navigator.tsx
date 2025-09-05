// Navigator.jsx
function Navigator() {
    const links = [
        { href: "/music", label: "Music" },
        { href: "/room", label: "Room" },
        { href: "/donate", label: "Donate" },
        { href: "/shop", label: "Shop" },
        { href: "/partners", label: "Partners" },
    ];

    return (
        <header className="fixed inset-x-0 top-0 z-50 bg-transparent">
            <nav className="mx-auto flex h-14 max-w-7xl items-center gap-8 px-6">
                {/* Logo */}
                <a href="/" className="text-2xl font-bold text-white">
                    ┏┛
                </a>

                {/* Navigation links */}
                <ul className="flex gap-6 text-sm font-medium text-white/90">
                    {links.map(({ href, label }) => (
                        <li key={href}>
                            <a
                                href={href}
                                className="
                  relative
                  text-white
                  after:absolute
                  after:inset-x-0
                  after:-bottom-1
                  after:h-0.5
                  after:scale-x-0
                  after:bg-pink-500
                  after:transition-transform
                  after:duration-200
                  hover:after:scale-x-100
                "
                            >
                                {label}
                            </a>
                        </li>
                    ))}
                </ul>

                {/* Search + Login */}
                <div className="ml-auto flex items-center gap-6">
                    <input
                        type="search"
                        placeholder="Search"
                        className="
              w-36 rounded-full bg-white/10 py-1.5 pl-4 pr-3 text-sm
              text-white placeholder:text-white/40
              focus:outline-none focus:ring-1 focus:ring-pink-500
            "
                    />
                    <a href="/login" className="           relative
                  text-white
                  after:absolute
                  after:inset-x-0
                  after:-bottom-1
                  after:h-0.5
                  after:scale-x-0
                  after:bg-pink-500
                  after:transition-transform
                  after:duration-200
                  hover:after:scale-x-100">
                        Login
                    </a>
                </div>
            </nav>
        </header>
    );
}

export default Navigator;
