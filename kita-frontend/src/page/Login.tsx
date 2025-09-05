import { useState } from 'react';
import { useNavigate } from 'react-router-dom';

const Login = () => {
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const [error, setError] = useState<string | null>(null);
    const navigate = useNavigate();

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        setError(null);
        try {
            const response = await fetch('https://localhost:7277/login', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({ Email: username, Password: password }),
            });

            const text = await response.json();

        if (response.ok) {
            const data = text;
            if (data.token) {
                localStorage.setItem('token', data.token);
                navigate('/');
            } else {
                setError('Authentication failed');
            }
        } else {
            setError('Invalid username or password');
        }
        } catch (error) {
            console.error("Error:", error);
            alert("Something went wrong");
  }
    };

    return (
        <div className="flex items-center justify-center min-h-screen px-4 bg-gray-100">
            <div 
                className="w-full max-w-md bg-white/90 backdrop-blur-sm rounded-lg shadow-xl p-8"
                style={{ 
                    background: 'rgba(255, 255, 255, 0.95)', 
                    boxShadow: '0 8px 32px rgba(0, 0, 0, 0.25)',
                    border: '1px solid rgba(255, 255, 255, 0.4)'
                }}
            >
                <h2 className="text-3xl font-bold mb-6 text-center text-gray-900">Login</h2>
                <form onSubmit={handleSubmit}>
                    <div className="mb-4">
                        <label htmlFor="username" className="block text-gray-800 text-sm font-semibold mb-2">Username</label>
                        <input
                            type="text"
                            id="username"
                            value={username}
                            onChange={e => setUsername(e.target.value)}
                            required
                            className="w-full px-3 py-2 border border-gray-300 rounded-md 
                                       focus:outline-none focus:ring-2 focus:ring-pink-500 text-gray-900"
                        />
                    </div>
                    <div className="mb-6">
                        <label htmlFor="password" className="block text-gray-800 text-sm font-semibold mb-2">Password</label>
                        <input
                            type="password"
                            id="password"
                            value={password}
                            onChange={e => setPassword(e.target.value)}
                            required
                            className="w-full px-3 py-2 border border-gray-300 rounded-md 
                                       focus:outline-none focus:ring-2 focus:ring-pink-500 text-gray-900"
                        />
                    </div>
                    {error && (
                        <div className="mb-4 text-red-600 font-medium text-center">
                            {error}
                        </div>
                    )}
                    <button 
                        type="submit" 
                        className="w-full bg-pink-500 hover:bg-pink-600 text-white font-bold py-3 px-4 rounded-md 
                                   transition duration-200 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-pink-500"
                    >
                        Login
                    </button>
                    <div className="mt-4 text-center">
                        <a href="/register" className="text-sm text-pink-600 hover:text-pink-800 font-medium">
                            Don't have an account? Register here
                        </a>
                    </div>
                </form>
            </div>
        </div>
    );
};

export default Login;
